public abstract class AObject
{
	public enum	Categorie
	{
		GEAR = 1,
		CONSUMABLE = 2,
		RESSOURCE = 4,
        ITEM = 7,
        SKILL = 8
	};

	public enum	Rarety
	{
		LEGENDARY,
		EPIC,
		RARE,
		COMMUN
	};

	public string	objectName = "";
    public string   description = "";

	public Categorie        categorie = Categorie.RESSOURCE;
	public Rarety           rarety = Rarety.COMMUN;
};
