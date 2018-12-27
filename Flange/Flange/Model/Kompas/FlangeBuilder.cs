using System;
using Flange.Model.Flange;
using Kompas6API5;

namespace Flange.Model.Kompas
{
    /// <summary>
    /// Строитель фланца.
    /// </summary>
    public class FlangeBuilder
    {
        /// <summary>
        /// Тип сущности - эскиз.
        /// </summary>
        private const int O3DSketch = 5;

        /// <summary>
        /// Верхний элемент.
        /// </summary>
        private const int PTopPart = -1;

        /// <summary>
        /// Плоскость XY.
        /// </summary>
        private const int O3DPlaneXoy = 1;

        /// <summary>
        /// Тип сущности - выдавливание.
        /// </summary>
        private const int O3DBaseExtrusion = 24;

        /// <summary>
        /// Тип обекта DrawMode.
        /// </summary>
        private const int VMShaded = 3;

        /// <summary>
        /// Тип выдавливания. Строго на глубину.
        /// </summary>
        private const int EtBlind = 0;

        /// <summary>
        /// Компас.
        /// </summary>
        private readonly Kompas _kompas;

        /// <summary>
        /// 3D-документ Компас.
        /// </summary>
        private Document3D _document3D;

        /// <summary>
        /// Деталь.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="kompas">Компас.</param>
        public FlangeBuilder(Kompas kompas)
        {
            _kompas = kompas;
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
            var numberOfBore = parameters[FlangeParameterNames.NumberOfBore];

            _document3D = _kompas.CreateDocument3D();

            _part = _document3D.GetPart(PTopPart);

            BuildBase(baseDiameter, centralHoleDiameter, numberOfBore, diameterForCenters, baseHeight, boreDiameter);

            BuildLift(liftDiameter, centralHoleDiameter, baseHeight, liftHeight);
        }

        /// <summary>
        /// Строит основу.
        /// </summary>
        /// <param name="baseDiameter">Диаметр основания.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        /// <param name="numberOfBore">Кол-во отверстий.</param>
        /// <param name="diameterForCenters">Диаметр для центров отверстий.</param>
        /// <param name="baseHeight">Базовая высота.</param>
        /// <param name="boreDiameter">Диаметр отверстий.</param>
        private void BuildBase(double baseDiameter, double centralHoleDiameter, double numberOfBore,
            double diameterForCenters, double baseHeight, double boreDiameter)
        {
            var entity = _part.NewEntity(O3DSketch);

            var sketchDefinition = entity.GetDefinition();

            var entityPlane = _part.GetDefaultEntity(O3DPlaneXoy);

            sketchDefinition.SetPlane(entityPlane);

            entity.Create();

            var document2D = (Document2D) sketchDefinition.BeginEdit();

            document2D.ksCircle(0, 0, baseDiameter / 2, 1);
            document2D.ksCircle(0, 0, centralHoleDiameter / 2, 1);

            var rotateAngle = 2 * Math.PI / numberOfBore;

            for (var i = 0; i < numberOfBore; i++)
                document2D.ksCircle(diameterForCenters / 2 * Math.Cos(rotateAngle * i),
                    diameterForCenters / 2 * Math.Sin(rotateAngle * i), boreDiameter / 2, 1);

            sketchDefinition.EndEdit();

            CreateExtrusion(baseHeight, entity);
        }

        /// <summary>
        /// Строит подъем.
        /// </summary>
        /// <param name="liftDiameter">Диаметр подъема.</param>
        /// <param name="centralHoleDiameter">Диаметр центрального отверстия.</param>
        /// <param name="baseHeight">Высота основания</param>
        /// <param name="liftHeight">Высота подъема.</param>
        private void BuildLift(double liftDiameter, double centralHoleDiameter, double baseHeight, double liftHeight)
        {
            var entity = _part.NewEntity(O3DSketch);

            var sketchDefinition = entity.GetDefinition();

            var entityPlane = _part.GetDefaultEntity(O3DPlaneXoy);

            sketchDefinition.SetPlane(entityPlane);

            entity.Create();

            var document2D = (Document2D) sketchDefinition.BeginEdit();

            document2D.ksCircle(0, 0, liftDiameter / 2, 1);
            document2D.ksCircle(0, 0, centralHoleDiameter / 2, 1);

            sketchDefinition.EndEdit();

            CreateExtrusion(baseHeight + liftHeight, entity);
        }

        /// <summary>
        /// Создает выдавливание.
        /// </summary>
        /// <param name="length">Глубина.</param>
        /// <param name="entity">Сущность.</param>
        private void CreateExtrusion(double length, ksEntity entity)
        {
            var entityExtrusion = _part.NewEntity(O3DBaseExtrusion);

            var baseExtrusionDefinition = entityExtrusion.GetDefinition;

            baseExtrusionDefinition.SetSideParam(true, EtBlind, length, 0, true);

            baseExtrusionDefinition.SetSketch(entity);

            entityExtrusion.Create();

            _document3D.drawMode = VMShaded;

            _document3D.shadedWireframe = true;
        }
    }
}