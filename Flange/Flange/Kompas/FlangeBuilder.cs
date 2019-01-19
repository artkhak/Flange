using System;
using Kompas6API5;
using Kompas6Constants3D;

namespace Flange.Kompas
{
    /// <summary>
    /// Строитель фланца.
    /// </summary>
    public class FlangeBuilder
    {
        /// <summary>
        /// Компас.
        /// </summary>
        private readonly KompasApp _kompas;

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="kompas">Компас.</param>
        public FlangeBuilder(KompasApp kompas)
        {
            _kompas = kompas ?? throw new ArgumentNullException(nameof(kompas));
        }

        /// <summary>
        /// Строит модель.
        /// </summary>
        /// <param name="parameters">Параметры фланца.</param>
        public void Build(FlangeParameters parameters)
        {
            var diameterForCenters = parameters[FlangeParameterNames.DiameterForCenters];
            var baseDiameter = parameters[FlangeParameterNames.BaseDiameter];
            var centralHoleDiameter = parameters[FlangeParameterNames.CentralHoleDiameter];
            var boreDiameter = parameters[FlangeParameterNames.BoreDiameter];
            var liftDiameter = parameters[FlangeParameterNames.LiftDiameter];
            var liftHeight = parameters[FlangeParameterNames.LiftHeight];
            var baseHeight = parameters[FlangeParameterNames.BaseHeight];
            var numberOfBore = (int) parameters[FlangeParameterNames.NumberOfBore];

            var document3D = _kompas.CreateDocument3D();
            _part = document3D.GetPart(PTopPart);

            BuildBase(baseDiameter, numberOfBore, diameterForCenters, baseHeight, boreDiameter);
            BuildLift(liftDiameter, baseHeight, liftHeight);

            var flangeHeight = baseHeight + liftHeight;

            BuildCentralHole(centralHoleDiameter, flangeHeight);
        }

        /// <summary>
        /// Строит центральное отверстие.
        /// </summary>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        /// <param name="flangeHeight">Высота фланца.</param>
        private void BuildCentralHole(double centralHoleDiameter, double flangeHeight)
        {
            var planeXoy = GetPlaneXoy();

            var sketch = CreateSketch(planeXoy);
            SketchDefinition sketchDefinition = sketch.GetDefinition();

            Document2D document2D = sketchDefinition.BeginEdit();

            PaintCircleSketch(document2D, centralHoleDiameter);

            sketchDefinition.EndEdit();

            ksEntity cutExtrusion = _part.NewEntity(O3DCutExtrusion);
            ksCutExtrusionDefinition cutExtrusionDefinition = cutExtrusion.GetDefinition();

            cutExtrusionDefinition.SetSketch(sketch);
            cutExtrusionDefinition.SetSideParam(true, 0, flangeHeight);

            cutExtrusion.Create();
        }

        /// <summary>
        /// Строит основание.
        /// </summary>
        /// <param name="baseDiameter">Диаметр основания.</param>
        /// <param name="numberOfBore">Кол-во отверстий.</param>
        /// <param name="diameterForCenters">Диаметр для центров отверстий.</param>
        /// <param name="baseHeight">Высота основания.</param>
        /// <param name="boreDiameter">Диаметр отверстий.</param>
        private void BuildBase(double baseDiameter, int numberOfBore,
            double diameterForCenters, double baseHeight, double boreDiameter)
        {
            var planeXoy = GetPlaneXoy();
            var sketch = CreateSketch(planeXoy);
            var sketchDefinition = sketch.GetDefinition();

            Document2D document2D = sketchDefinition.BeginEdit();

            PaintCircleSketch(document2D, baseDiameter);
            PaintBoresSketch(document2D, diameterForCenters, numberOfBore, boreDiameter);

            sketchDefinition.EndEdit();

            CreateExtrusion(baseHeight, sketch);
        }

        /// <summary>
        /// Рисует эскиз окружности.
        /// </summary>
        /// <param name="document2D">2D документ.</param>
        /// <param name="diameter">Диаметр.</param>
        /// <param name="xCenter">Абцисса центра окружности.</param>
        /// <param name="yCenter">Ордината центра окружности.</param>
        private static void PaintCircleSketch(ksDocument2D document2D, double diameter, double xCenter = 0,
            double yCenter = 0)
        {
            document2D.ksCircle(xCenter, yCenter, diameter / 2, 1);
        }

        /// <summary>
        /// Рисует эскиз отверстий.
        /// </summary>
        /// <param name="document2D">2D документ.</param>
        /// <param name="diameterForCenters">Диаметр для центров отверстий.</param>
        /// <param name="numberOfBore">Количество отверстий.</param>
        /// <param name="boreDiameter">Диаметр отверстий.</param>
        private static void PaintBoresSketch(ksDocument2D document2D, double diameterForCenters, int numberOfBore,
            double boreDiameter)
        {
            var rotationAngle = 2 * Math.PI / numberOfBore;

            for (var i = 0; i < numberOfBore; i++)
            {
                var currentRotationAngle = rotationAngle * i;
                var currentXCenter = diameterForCenters / 2 * Math.Cos(currentRotationAngle);
                var currentYCenter = diameterForCenters / 2 * Math.Sin(currentRotationAngle);

                PaintCircleSketch(document2D, boreDiameter, currentXCenter, currentYCenter);
            }
        }

        /// <summary>
        /// Строит подъем.
        /// </summary>
        /// <param name="liftDiameter">Диаметр подъема.</param>
        /// <param name="baseHeight">Высота основания</param>
        /// <param name="liftHeight">Высота подъема.</param>
        private void BuildLift(double liftDiameter, double baseHeight, double liftHeight)
        {
            var basePlaneXoy = GetPlaneXoy();
            var planeOffset = CreatePlaneOffset(basePlaneXoy, baseHeight);

            var sketch = CreateSketch(planeOffset);
            SketchDefinition sketchDefinition = sketch.GetDefinition();

            Document2D document2D = sketchDefinition.BeginEdit();

            PaintCircleSketch(document2D, liftDiameter);

            sketchDefinition.EndEdit();

            CreateExtrusion(liftHeight, sketch, true);

            ksEntityCollection faceCollection = _part.EntityCollection(O3DFace);
            
            var flangeHeight = baseHeight + liftHeight;

            faceCollection.SelectByPoint(0, 0, flangeHeight);
            ksEntity chamferFace = faceCollection.First();

            CreateChamfer(liftHeight, chamferFace);
        }

        /// <summary>
        /// Строит фаску для ребра.
        /// </summary>
        /// <param name="height">Высота фаски.</param>
        /// <param name="face">Грань.</param>
        private void CreateChamfer(double height, ksEntity face)
        {
            ksEntity chamferIn = _part.NewEntity(O3DChamfer);

            ksChamferDefinition chamferDefinitionIn = chamferIn.GetDefinition();

            chamferDefinitionIn.tangent = true;
            chamferDefinitionIn.SetChamferParam(false, height, height);

            ksEntityCollection entityCollectionChamferIn = chamferDefinitionIn.array();

            entityCollectionChamferIn.Add(face);

            chamferIn.Create();
        }

        /// <summary>
        /// Создает выдавливание.
        /// </summary>
        /// <param name="length">Глубина.</param>
        /// <param name="entity">Сущность.</param>
        private void CreateExtrusion(double length, ksEntity entity, bool needChamfer = false)
        {
            ksEntity extrusion = _part.NewEntity(O3DBaseExtrusion);
            BaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

            var draft = needChamfer ? length : 0;

            extrusionDefinition.SetSideParam(true, EtBlind, length, draft, needChamfer);
            extrusionDefinition.SetSketch(entity);
            extrusion.Create();
        }

        /// <summary>
        /// Создает плоскость со сдвигом параллельно базовой плоскости.
        /// </summary>
        /// <param name="basePlane">Базовая плоскость.</param>
        /// <param name="offset">Сдвиг.</param>
        /// <returns>Плоскость со сдвигом</returns>
        private ksEntity CreatePlaneOffset(ksEntity basePlane, double offset)
        {
            ksEntity planeOffset = _part.NewEntity(O3DPlaneOffset);
            ksPlaneOffsetDefinition planeOffsetDefinition = planeOffset.GetDefinition();

            planeOffsetDefinition.direction = true;
            planeOffsetDefinition.offset = offset;
            planeOffsetDefinition.SetPlane(basePlane);

            planeOffset.Create();

            return planeOffset;
        }

        /// <summary>
        /// Получает базовую плоскость XOY.
        /// </summary>
        /// <returns>Базовая плоскость XOY.</returns>
        private ksEntity GetPlaneXoy()
        {
            return _part.GetDefaultEntity(O3DPlaneXoy);
        }

        /// <summary>
        /// Создает эскиз.
        /// </summary>
        /// <param name="plane">Плоскость для эскиза.</param>
        /// <returns>Эскиз.</returns>
        private ksEntity CreateSketch(ksEntity plane)
        {
            ksEntity sketch = _part.NewEntity(O3DSketch);
            SketchDefinition sketchDefinition = sketch.GetDefinition();

            sketchDefinition.SetPlane(plane);
            sketch.Create();

            return sketch;
        }

        #region Константы Компаса

        /// <summary>
        /// Тип сущности - эскиз.
        /// </summary>
        private const short O3DSketch = (short) Obj3dType.o3d_sketch;

        /// <summary>
        /// Верхний элемент.
        /// </summary>
        private const short PTopPart = (short) Part_Type.pTop_Part;

        /// <summary>
        /// Плоскость XY.
        /// </summary>
        private const short O3DPlaneXoy = (short) Obj3dType.o3d_planeXOY;

        /// <summary>
        /// Смещенная плоскость.
        /// </summary>
        private const short O3DPlaneOffset = (short) Obj3dType.o3d_planeOffset;

        /// <summary>
        /// Тип сущности - выдавливание.
        /// </summary>
        private const short O3DBaseExtrusion = (short) Obj3dType.o3d_baseExtrusion;

        /// <summary>
        /// Тип сущности - вырезание выдавливанием.
        /// </summary>
        private const short O3DCutExtrusion = (short) Obj3dType.o3d_cutExtrusion;

        /// <summary>
        /// Тип выдавливания. Строго на глубину.
        /// </summary>
        private const short EtBlind = (short) End_Type.etBlind;

        /// <summary>
        /// Тип сущности - фаска.
        /// </summary>
        private const short O3DChamfer = (short) Obj3dType.o3d_chamfer;

        /// <summary>
        /// Тип сущности - поверхность.
        /// </summary>
        private const short O3DFace = (short) Obj3dType.o3d_face;

        #endregion
    }
}