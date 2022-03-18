using DIKUArcade.Entities;
using DIKUArcade.Graphics;


namespace Galaga {

    public class Enemy : Entity {

        private int hitPoints = 60;

        public int HitPoints{
            get{return hitPoints;}
            set{hitPoints = value;}
        }

        private IBaseImage strideToBe;
        private IBaseImage alternativeStride;
        
        
        
        public Enemy(DynamicShape shape, IBaseImage strideToBe/*, IBaseImage alternativeStride*/)
        : base(shape, strideToBe) {
            
         }
        
    }

}