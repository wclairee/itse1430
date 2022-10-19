//ITSE 1430 
//Fall 2022
//Claire Walker

namespace ClaireWalker.CharacterCreator
{

    /// <summary>Represents the created character.</summary>
    public class Character
    {
        /// <summary>Gets or sets the name of the character.</summary>
        public string Name { get { return _name ?? ""; } set { _name = value?.Trim() ?? ""; } }
        private string _name;

        /// <summary>Gets or sets the profession of the character.</summary>
        public string Profession { get { return _profession ?? ""; } set { _profession = value?.Trim() ?? ""; } }
        private string _profession;

        /// <summary>Gets or sets the race of the character.</summary>
        public string Race { get { return _race ?? ""; } set { _race = value?.Trim() ?? ""; } }
        private string _race;

        /// <summary>Gets or sets the background of the character.</summary>
        public string Background { get { return _background ?? ""; } set { _background = value?.Trim() ?? ""; } }
        private string _background;

        /// <summary>Gets or sets the strength rating of the character.</summary>
        public int Strength { get { return _strength; } set { _strength = value; } }
        private int _strength;

        /// <summary>Gets or sets the charisma rating of the character.</summary>
        public int Charisma { get { return _charisma; } set { _charisma = value; } }
        private int _charisma;

        /// <summary>Gets or sets the intelligence rating of the character.</summary>
        public int Intelligence { get { return _intelligence; } set { _intelligence = value; } }
        private int _intelligence;

        /// <summary>Gets or sets the agility rating of the character.</summary>
        public int Agility { get { return _agility; } set { _agility = value; } }
        private int _agility;

        /// <summary>Gets or sets the constitution rating for the character.</summary>
        public int Constitution { get { return _constitution; } set { _constitution = value; } }
        private int _constitution;
    }
}
