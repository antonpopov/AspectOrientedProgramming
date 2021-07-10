namespace DecoratorPatternDemo.Services.Superheros.Decorators
{
    using DecoratorPatternDemo.Models.Superheros;
    using System.Collections.Generic;
    using System.Transactions;

    public class TransactionDecorator : ISuperherosService
    {
        private readonly ISuperherosService superherosService;

        public TransactionDecorator(ISuperherosService superherosService)
        {
            this.superherosService = superherosService;
        }

        public Superhero Delete(int id)
        {
            using (var scope = new TransactionScope())
            {
                var result = this.superherosService.Delete(id);

                scope.Complete();

                return result;
            }
        }

        public Superhero Get(int id)
        {
            using (var scope = new TransactionScope())
            {
                var result = this.superherosService.Get(id);

                scope.Complete();

                return result;
            }
        }

        public IEnumerable<Superhero> GetAll()
        {
            using (var scope = new TransactionScope())
            {
                var result = this.superherosService.GetAll();

                scope.Complete();

                return result;
            }
        }

        public Superhero Update(Superhero updatedSuperhero)
        {
            using (var scope = new TransactionScope())
            {
                var result = this.superherosService.Update(updatedSuperhero);

                scope.Complete();

                return result;
            }
        }
    }
}
