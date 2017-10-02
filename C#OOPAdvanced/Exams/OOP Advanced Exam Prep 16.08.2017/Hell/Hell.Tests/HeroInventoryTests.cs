using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory sut;

    [SetUp]
    public void TestInit()
    {
        this.sut = new HeroInventory();
    }

    [Test]
    public void Constructor_WithNewInstance_ShouldHaveEmptyCommonItemsDictionary()
    {
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.AreEqual(0, collection.Count);
    }

    [Test]
    public void Constructor_WithNewInstance_ShouldHaveEmptyCommonRecipeDictionary()
    {
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetField("recipeItems", BindingFlags.NonPublic | BindingFlags.Instance);
        var collection = (Dictionary<string, IRecipe>)field.GetValue(this.sut);

        Assert.AreEqual(0, collection.Count);
    }

    [Test]
    public void AddCommonItem()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void AddCommonItem_ThatCanBeCombined_ShouldAddTheRecipeToCommonItems()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);
        
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.IsTrue(collection.ContainsKey(recipe.Name));
    }

    [Test]
    public void AddCommonItemAndRecipeItem_ThatCanBeCombined_ShouldAddTheRecipeToCommonItems()
    {
        CommonItem item1 = new CommonItem("item1", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item1);

        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item1", "item2" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item2 = new CommonItem("item2", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item2);

        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.IsTrue(collection.ContainsKey(recipe.Name));
    }

    [Test]
    public void AddRecipe_ThatCanBeCombined_ShouldNotBeAddeddToRecipes()
    {
        CommonItem item1 = new CommonItem("item1", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item1);

        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() {"item"});
        this.sut.AddRecipeItem(recipe);

        Type clazz = typeof(HeroInventory);
        var field = clazz.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);

        var collection = (Dictionary<string, IRecipe>)field.GetValue(this.sut);

        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void AddRecipe_ThatCanBEcombined_ShoudlAddToComoniTems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.IsTrue(collection.ContainsKey(recipe.Name));
    }

    [Test]
    public void AddRecipe_ThatCanNotBeCombined_ShouldNotAddItemToCommonItems()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "someeles" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.IsFalse(collection.ContainsKey(recipe.Name));
    }

    [Test]
    public void AddCommonItem_ThatCanBeCombined_ShouldTakeTheAgilityBonusOfTheRecipe()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(12, this.sut.TotalAgilityBonus);
    }

    [Test]
    public void AddCommonItem_ThatCanBeCombined_ShouldTakeTheStrengthBonusOfTheRecipe()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(11, this.sut.TotalStrengthBonus);
    }

    [Test]
    public void AddCommonItem_ThatCanBeCombined_ShouldTakeTheIntelligenceBonusOfTheRecipe()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(13, this.sut.TotalIntelligenceBonus);
    }

    [Test]
    public void AddCommonItem_ThatCanBeCombined_ShouldTakeTheHitpointsBonusBonusOfTheRecipe()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(14, this.sut.TotalHitPointsBonus);
    }

    [Test]
    public void AddCommonItem_ThatCanBeCombined_ShouldTakeThedamageBonusOfTheRecipe()
    {
        RecipeItem recipe = new RecipeItem("recipe", 11, 12, 13, 14, 15, new List<string>() { "item" });
        this.sut.AddRecipeItem(recipe);

        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);
        this.sut.AddCommonItem(item);

        Assert.AreEqual(15, this.sut.TotalDamageBonus);
    }

    [Test]
    public void AddRecipeItem()
    {
        RecipeItem item = new RecipeItem("item", 1, 2, 3, 4, 5, new List<string>());

        this.sut.AddRecipeItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);

        var collection = (Dictionary<string, IRecipe>)field.GetValue(this.sut);

        Assert.AreEqual(1, collection.Count);
    }


    [Test]
    public void StrengthBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(1, this.sut.TotalStrengthBonus);
    }

    [Test]
    public void AgilityBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(2, this.sut.TotalAgilityBonus);
    }

    [Test]
    public void IntelligenceBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(3, this.sut.TotalIntelligenceBonus);
    }

    [Test]
    public void HitPointsBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(4, this.sut.TotalHitPointsBonus);
    }

    [Test]
    public void DamageBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.sut.AddCommonItem(item);

        Assert.AreEqual(5, this.sut.TotalDamageBonus);
    }
}