namespace LoggingExceptionHandlingTransactioningCccDemo.Services.Superheros
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Transactions;

    using LoggingExceptionHandlingTransactioningCccDemo.Models.Superheros;
    using LoggingExceptionHandlingTransactioningCccDemo.Services.Logging;

    public class SuperherosService : ISuperherosService
    {
        private static readonly IList<Superhero> Superheros = new List<Superhero>
        {
            new Superhero
            {
                Id = IdProvider.GenerateId(),
                Name = "Batman",
                RealName = "Bruce Wayne",
                Universe = Universe.Dc
            },
            new Superhero
            {
                Id = IdProvider.GenerateId(),
                Name = "Wolverine",
                RealName = "Logan",
                Universe = Universe.Marvel
            }
        };
        private readonly ILoggerService loggerService;
        private readonly IDateTimeProvider dateTimeProvider;

        public SuperherosService(ILoggerService loggerService, IDateTimeProvider dateTimeProvider)
        {
            this.loggerService = loggerService;
            this.dateTimeProvider = dateTimeProvider;
        }

        public Superhero Get(int id)
        {
            // Logging
            this.loggerService
                    .Log($"Stepped in {nameof(this.Get)} at {this.dateTimeProvider.GetDateTimeNow()}");

            // Exception handling
            Superhero superhero = null;
            try
            {
                using (var scope = new TransactionScope())
                {
                    superhero = Superheros
                        .FirstOrDefault(x => x.Id == id);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            // Logging
            this.loggerService
                    .Log($"Stepped out of {nameof(this.Get)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return superhero;
        }

        public IEnumerable<Superhero> GetAll()
        {
            // Logging
            this.loggerService
                    .Log($"Stepped in {nameof(this.GetAll)} at {this.dateTimeProvider.GetDateTimeNow()}");

            // Exception handling
            IEnumerable<Superhero> superheros = null;
            try
            {
                using (var scope = new TransactionScope())
                {
                    superheros = Superheros.ToList();
                }
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            // Logging
            this.loggerService
                    .Log($"Stepped out of {nameof(this.GetAll)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return superheros;
        }

        public Superhero Update(Superhero updatedSuperhero)
        {
            // Logging
            this.loggerService
                    .Log($"Stepped in {nameof(this.Update)} at {this.dateTimeProvider.GetDateTimeNow()}");

            // Exception handling
            try
            {
                using (var scope = new TransactionScope())
                {
                    var existingSuperhero = Superheros
                                .SingleOrDefault(x => x.Id == updatedSuperhero.Id);

                    Superheros.Remove(existingSuperhero);
                    Superheros.Add(updatedSuperhero);
                }
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            // Logging
            this.loggerService
                    .Log($"Stepped out of {nameof(this.Update)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return updatedSuperhero;
        }

        public Superhero Delete(int id)
        {
            // Logging
            this.loggerService
                    .Log($"Stepped in {nameof(this.Delete)} at {this.dateTimeProvider.GetDateTimeNow()}");

            // Exception handling
            Superhero existingSuperhero = null;
            try
            {
                using (var scope = new TransactionScope())
                {
                    existingSuperhero = Superheros
                        .SingleOrDefault(x => x.Id == id);
                }
            }
            catch (Exception ex)
            {
                this.loggerService
                        .Log($"{ex.Message}{Environment.NewLine}{ex.Message}{Environment.NewLine}");

                throw;
            }

            // Logging
            this.loggerService
                    .Log($"Stepped out of {nameof(this.Delete)} at {this.dateTimeProvider.GetDateTimeNow()}");

            return existingSuperhero;
        }
    }
}
