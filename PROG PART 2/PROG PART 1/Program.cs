using System;
using System.Text;
using System.Xml;
//prog
internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Recipe> dictionaryRecipe = new Dictionary<string, Recipe>();
        Appmenu menu = new Appmenu(dictionaryRecipe);
        menu.appmenu();
    }

}
class recipelogger
{
    private Dictionary<string, Recipe> dictionaryRecipe;

    public recipelogger(Dictionary<string, Recipe> dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
    }

    public void logDetails()
    {
        Console.WriteLine("Enter the number of recipes:");
        int recipeNum;
        if (int.TryParse(Console.ReadLine(), out recipeNum))
        {
            for (int i = 0; i < recipeNum; i++)
            {
                Console.WriteLine("Enter Recipe Name:");
                String recipeName = Console.ReadLine();
                Recipe recipe = new Recipe();
                recipe.EnterData();
                dictionaryRecipe.Add(recipeName, recipe);
            }
            String ans;
            do
            {
                Console.WriteLine("Display Ingredients And steps?(Y/N)");
                ans = Console.ReadLine();
                switch (ans)
                {
                    case "Y":
                        foreach (var recipeEntry in dictionaryRecipe)
                        {
                            Console.WriteLine($"Recipe Name:{recipeEntry.Key}");
                            recipeEntry.Value.RecipeDisplay();
                        }
                        break;
                    case "N":
                        Appmenu menu = new Appmenu(dictionaryRecipe);
                        menu.appmenu();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }
            } while (ans != "N");
        }
        else
        {
            Console.WriteLine("please enter a number");
        }
    }
        public void recipeList()
    {
        foreach (var recipeEntry in dictionaryRecipe)
        {
            Console.WriteLine($"Recipe Name:{recipeEntry.Key}");
        }
    }
    public void recipeFinder()
    {
        Console.Write("Please enter the name of the recipe:");
        String recipeName = Console.ReadLine();
        if(dictionaryRecipe.ContainsKey(recipeName))
        {
            Console.WriteLine($"Recipe Name:{recipeName}");
            dictionaryRecipe[recipeName].RecipeDisplay();
        }
        else
        {
            Console.WriteLine("Recipe does not exist");
        }
    }
}
class IngredientMenu
{
    private Dictionary<String, Recipe>dictionaryRecipe;

    public IngredientMenu(Dictionary<string, Recipe> dictionaryRecipe)
    {
        this.dictionaryRecipe = dictionaryRecipe;
        Recipe recipe = new Recipe();
        while (true)
        {
            Console.WriteLine("=========");
            Console.WriteLine("Enter 1 to enter recipe details");
            Console.WriteLine("Enter 2 to Display Recipe");
            Console.WriteLine("Enter 3 to Scale Recipe");
            Console.WriteLine("Enter 4 to Reset quantity");
            Console.WriteLine("Enter 5 to Clear recipe");
            Console.WriteLine("Enter 6 to go back to main menu");
            Console.WriteLine("=========");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    recipe.EnterData();
                    break;
                case "2":
                    recipe.RecipeDisplay();
                    break;
                case "3":
                    Console.WriteLine("Enter a scale of 0.5, 2 or 3");
                    double scale1 = Convert.ToDouble(Console.ReadLine());
                    recipe.RecipeScale(scale1);
                    break;
                case "4":
                    recipe.ResetRecipe();
                    break;
                case "5":
                    recipe.ClearRecipe();
                    break;
                case "6":
                    Appmenu appMenu = new Appmenu(dictionaryRecipe);
                    appMenu.appmenu();
                    break;
                default:
                    Console.WriteLine(" wrong value. please try again");
                    break;
            }
        }
    }
}

class Recipe
{
    private String[] Ingredients;
    private double[] amount;
    private String[] units;
    private String[] steps;
    private double[] calories;
    private string[] foodgroup;

    public Recipe()
    {
        Ingredients = new String[0];
        amount = new double[0];
        units = new String[0];
        steps = new String[0];
        calories = new double[0];
        foodgroup = new String[0];
    }
    public void EnterData()


    {
        Console.WriteLine("Enter number of ingredients");
        int ingnum = Convert.ToInt32(Console.ReadLine());

        Ingredients= new String[ingnum];
        amount = new double[ingnum];
        units = new String[ingnum];
        calories = new double[ingnum];
        foodgroup = new String[ingnum];

        for(int i = 0; i< ingnum; i++)
        {
            Console.WriteLine($"Enter ingredients details#{i+1}:");
            Console.Write("Name");
            Ingredients[i] = Console.ReadLine();
            do
            {
                Console.Write("quantity");
            }while(double.TryParse(Console.ReadLine(), out amount[i]));
            Console.Write("units of measurements");
            units[i] = Console.ReadLine();
            do
            {
                Console.Write("Number of calories");
            } while (double.TryParse(Console.ReadLine(), out calories[i]));

            Console.Write("Enter Food Group:");
            foodgroup[i] = Console.ReadLine();
        }
        //Delegation
        double caloriesExceed = caloriesTotal(calories);
        Console.WriteLine("Total Calories:"+ caloriesExceed);
        if(caloriesExceed>300)
        {
            Console.WriteLine("!!!Total calories Exceed 300!!!");
        }
        int stpNum;
        do
        {
            Console.WriteLine("Enter Number of steps:");
        } while (!int.TryParse(Console.ReadLine(), out stpNum));

        steps = new String[stpNum];
        {

        }

        for (int a = 0; a<stpNum; a++) 
        {
            Console.Write($"Steps#{a+1}:");
            steps[a] = Console.ReadLine();
        }

    }

    public void RecipeDisplay()
    {
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < Ingredients.Length; i++)
        {
            Console.WriteLine($"- {amount[i]}{units[i]} of {Ingredients[i]}");
        }
        Console.WriteLine("steps:");
        for(int a = 0; a < Ingredients.Length; a++)
        {
            Console.WriteLine($"-{steps[a]}");

        }
        double result = 0;
        for (int i = 0; i < calories.Length; i++)
        {
            result += calories[i];
        }
        if (result > 300)
        {
            Console.WriteLine("!!!Total calories Exceed 300!!!");
        }

    }
    public double caloriesTotal(double[]calories)
    {
        double result = 0;
        for(int i = 0;i<calories.Length;i++)
        {
            result += calories[i];
        }
        return result;
    }
    public void RecipeScale(double scale)
    {
        for (int i=0; i < amount.Length; i++)
        {
            amount[i] *= scale;
        }
    }

    public void ResetRecipe()
    {
        for (int i = 0; i<amount. Length; i++)
            {
            amount[i] /= 2;
        }
    }

    public void ClearRecipe()
    {
        //
        Ingredients = new String[0];
        amount = new double[0];
        units = new String[0];
        steps = new String[0];
    }


}
class Appmenu
{
    private Dictionary<String, Recipe> _dictionaryRecipe;
    private recipelogger repl;

    public Appmenu(Dictionary<string, Recipe> dictionaryRecipe)
    {
        dictionaryRecipe = dictionaryRecipe;
        repl= new recipelogger(dictionaryRecipe);
            }

    public void appmenu()
    {
        while (true)
        {
            Console.WriteLine("==================");
            Console.WriteLine("RECIPE APP");
            Console.WriteLine("1) Create Recipe");
            Console.WriteLine("2) Search for Recipe");
            Console.WriteLine("3) Display Recipe");
            Console.WriteLine("4) Exit Application");
            Console.WriteLine("==================");
            Console.WriteLine("Please Select an Option");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    repl.logDetails();
                    break;
                    case "2" :
                    repl.recipeFinder();
                    break;
                    case "3" :
                    repl.recipeList();
                    break;
                    case "4" :  
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("please enter a valid input");
                    break;


            }

        }
    }

}