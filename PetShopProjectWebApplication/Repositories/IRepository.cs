using PetShopProjectWebApplication.Models;

namespace PetShopProjectWebApplication.Repositories
{
    public interface IRepository
    {
        //Read
        IEnumerable<Animal> GetAnimals();
        Animal? GetAnimal(int id);
        IEnumerable<Animal> SearchAnimals(string text);
        IEnumerable<Animal> GetMostPopularAnimals(int count);
        IEnumerable<Category> GetCategory(string categoryName = "All");
        Category? GetCategoryById(int id);

        //Write\Delete
        void AddAnimal(Animal animal);
        void DeleteAnimal(int id);
        void AddComment(int animalId, string comment);
        void Update();
		void AddCategory(Category newCategory);
		void DeleteCategory(int id);
	}
}
