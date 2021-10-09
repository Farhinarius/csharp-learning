using System;

namespace Workspace.Learning.GenericsEssence.Resources
{
    public class Airplane
    {
        #region Nested
        
        public enum Model
        {
            Passenger,
            Private,
            Business,
            Corporate 
        }
        
        #endregion
        
        # region Static

        private static readonly Array Models;

        private static readonly Random Random;
        
        static Airplane()
        {
            Random = new Random();
            Models = Enum.GetValues(typeof(Model));
        }

        public static Model RandomModel =>
            (Model?) Models.GetValue(Random.Next(Models.Length)) 
            ?? throw new NullReferenceException();

        #endregion

        public Model ModelType;
        
        public Airplane()
        {
            ModelType = RandomModel;
        }
        
        public Airplane(Model modelType)
        {
            ModelType = modelType;
        }
    }
}