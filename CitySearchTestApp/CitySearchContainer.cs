using Autofac;
using CitySearch;
using CitySearch.Interfaces;

namespace CitySearchTestApp
{
    /// <summary>
    /// The IOC container.
    /// </summary>
    public class CitySearchContainer
    {
        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>The container.</returns>
        internal static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CityFinder>();
            builder.RegisterType<CityNameFinder>().As<ICityNameFinder>();
            builder.RegisterType<UserInputValidator>().As<IValidator>();
            builder.RegisterType<CityNextLetterHelper>().As<ICityNextLetterHelper>();
            builder.RegisterType<CityResult>().As<ICityResult>();
            builder.RegisterType<CityListRepository>().As<ICityListRepository>();

            return builder.Build();
        }
    }
}
