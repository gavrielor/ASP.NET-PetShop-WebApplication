using PetShopProjectWebApplication.Data;
using PetShopProjectWebApplication.Models;

namespace PetShopProjectWebApplication.Repositories
{
    public class PetShopRepository : IRepository
    {
        private DataContext context;

        public PetShopRepository(DataContext context)
        {
            this.context = context;
        }

        public void AddAnimal(Animal animal)
        {
            context.Animals!.Add(animal);
            context.SaveChanges();
        }
        
        public IEnumerable<Animal> GetAnimals() => context.Animals!;
        
        public IEnumerable<Animal> GetMostPopularAnimals(int count) => GetAnimals().OrderBy(a => -a.Comments!.Count).Take(count);
        
        public IEnumerable<Category> GetCategory(string categoryName = "All")
        {
            var categories = context.Categories!;
            return (categoryName == "All") ? categories : categories.Where(c => c.Name == categoryName);
        }

        public Animal? GetAnimal(int id)
        {
            return context.Animals!.FirstOrDefault(a => a.Id == id);
        }

        public void AddComment(int animalId, string comment)
        {
            var animal = GetAnimal(animalId);
            if (animal != null) animal.Comments!.Add(new Comment { Content = comment });
            context.SaveChanges();
        }

        public Category? GetCategoryById(int id)
        {
            return context.Categories!.FirstOrDefault(c => c.Id == id);
        }

        public void DeleteAnimal(int id)
        {
            var animal = GetAnimal(id);
            if (animal != null)
            {
                foreach (var comment in animal.Comments!)
                {
                    context.Comments!.Remove(comment);
                }
                context.Animals!.Remove(animal);
            }
            context.SaveChanges();
        }

        public void Update() => context.SaveChanges();

        public IEnumerable<Animal> SearchAnimals(string text)
        {
            return context.Animals!.Where(a => a.Name!.ToUpper().Contains(text.ToUpper()));
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category!.Animals!.Count == 0)
            {
                context.Categories!.Remove(category);
                context.SaveChanges();
            }
        }

        public void AddCategory(Category newCategory)
        {
            context.Categories!.Add(newCategory);
            context.SaveChanges();
        }
    }
}
