using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PokedexApi.Model
{
    [Table("pokemon")]
    public class Pokemon
    {
        [Key]
        [Column("pokedex_number")]
        public int PokedexNumber { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("japanese_name")]
        public string JapaneseName { get; set; }

        [Column("percentage_male")]
        public decimal? PercentageMale { get; set; }

        [Column("type1")]
        public string Type1 { get; set; }

        [Column("type2")]
        public string Type2 { get; set; }

        [Column("classification")]
        public string Classification { get; set; }

        [Column("height_m")]
        public decimal HeightM { get; set; }

        [Column("weight_kg")]
        public decimal WeightKg { get; set; }

        [Column("capture_rate")]
        public int CaptureRate { get; set; }

        [Column("base_egg_steps")]
        public int BaseEggSteps { get; set; }

        [Column("abilities")]
        public string AbilitiesString { get; set; }

        [NotMapped]
        public List<string> Abilities
        {
            get => AbilitiesString?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() ?? [];
            set => AbilitiesString = string.Join(",", value);
        }

        [Column("experience_growth")]
        public int ExperienceGrowth { get; set; }

        [Column("base_happiness")]
        public int BaseHappiness { get; set; }

        [Column("against_normal")]
        public decimal AgainstNormal { get; set; }

        [Column("against_fire")]
        public decimal AgainstFire { get; set; }

        [Column("against_water")]
        public decimal AgainstWater { get; set; }

        [Column("against_electric")]
        public decimal AgainstElectric { get; set; }

        [Column("against_grass")]
        public decimal AgainstGrass { get; set; }

        [Column("against_ice")]
        public decimal AgainstIce { get; set; }

        [Column("against_fight")]
        public decimal AgainstFight { get; set; }

        [Column("against_poison")]
        public decimal AgainstPoison { get; set; }

        [Column("against_ground")]
        public decimal AgainstGround { get; set; }

        [Column("against_flying")]
        public decimal AgainstFlying { get; set; }

        [Column("against_psychic")]
        public decimal AgainstPsychic { get; set; }

        [Column("against_bug")]
        public decimal AgainstBug { get; set; }

        [Column("against_rock")]
        public decimal AgainstRock { get; set; }

        [Column("against_ghost")]
        public decimal AgainstGhost { get; set; }

        [Column("against_dragon")]
        public decimal AgainstDragon { get; set; }

        [Column("against_dark")]
        public decimal AgainstDark { get; set; }

        [Column("against_steel")]
        public decimal AgainstSteel { get; set; }

        [Column("against_fairy")]
        public decimal AgainstFairy { get; set; }

        [Column("hp")]
        public int Hp { get; set; }

        [Column("attack")]
        public int Attack { get; set; }

        [Column("defense")]
        public int Defense { get; set; }

        [Column("sp_attack")]
        public int SpAttack { get; set; }

        [Column("sp_defense")]
        public int SpDefense { get; set; }

        [Column("speed")]
        public int Speed { get; set; }

        [Column("generation")]
        public int Generation { get; set; }

        [Column("is_legendary")]
        public bool IsLegendary { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("price")]
        public int Price { get; set; }
    }
}
