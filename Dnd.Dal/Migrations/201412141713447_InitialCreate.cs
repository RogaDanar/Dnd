namespace Dnd.Dal.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up() {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Race = c.Int(nullable: false),
                        HitpointsCurrent = c.Int(nullable: false),
                        HitpointsMax = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CharacterAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartStrength = c.Int(nullable: false),
                        StartDexterity = c.Int(nullable: false),
                        StartConstitution = c.Int(nullable: false),
                        StartIntelligence = c.Int(nullable: false),
                        StartWisdom = c.Int(nullable: false),
                        StartCharisma = c.Int(nullable: false),
                        ModStrength = c.Int(nullable: false),
                        ModDexterity = c.Int(nullable: false),
                        ModConstitution = c.Int(nullable: false),
                        ModIntelligence = c.Int(nullable: false),
                        ModWisdom = c.Int(nullable: false),
                        ModCharisma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.CharacterClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);

            CreateTable(
                "dbo.CharacterFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feature = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);

            CreateTable(
                "dbo.CharacterSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Ranks = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .Index(t => t.CharacterId);

        }

        public override void Down() {
            DropForeignKey("dbo.CharacterSkills", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterFeatures", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterClasses", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.CharacterAbilities", "Id", "dbo.Character");
            DropIndex("dbo.CharacterSkills", new[] { "CharacterId" });
            DropIndex("dbo.CharacterFeatures", new[] { "CharacterId" });
            DropIndex("dbo.CharacterClasses", new[] { "CharacterId" });
            DropIndex("dbo.CharacterAbilities", new[] { "Id" });
            DropTable("dbo.CharacterSkills");
            DropTable("dbo.CharacterFeatures");
            DropTable("dbo.CharacterClasses");
            DropTable("dbo.CharacterAbilities");
            DropTable("dbo.Character");
        }
    }
}
