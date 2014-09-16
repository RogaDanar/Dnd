namespace Dnd.Web.ViewModels
{
    using Core.Model.Character;
    using Core.Model.Races;

    public class CharacterViewModel
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public Size Size { get; set; }
        public int Speed { get; set; }
        public int HitpointsCurrent { get; set; }
        public int HitpointsMax { get; set; }
        public int ExperienceCurrent { get; set; }
        public int ExperienceLevel { get; set; }

        //public AttributeList Attributes { get; set; }
        //public SavesList Saves { get; set; }
        //public AttackList Attacks { get; set; }
        //public FeatureList Features { get; set; }
        //public SkillList Skills { get; set; }
        //public Equipment Equipment { get; set; }
        //public Dictionary<ClassType, IClass> Classes { get; set; }
    }
}