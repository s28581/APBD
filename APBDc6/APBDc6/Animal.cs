namespace APBDc6;

public class Animal
{
    public int IdAnimal { get; }
    private static int IdCounter = 0;
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public string Area { get; set; }

    public Animal(string name, string description, Category category, string area)
    {
        IdAnimal = IdCounter;
        IdCounter++;
        Name = name;
        Description = description;
        Category = category;
        Area = area;
    }
}