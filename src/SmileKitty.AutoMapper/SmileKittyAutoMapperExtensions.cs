using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SmileKitty.AutoMapper;

public static class SmileKittyAutoMapperExtensions
{
    private static IMapper _mapper = null!;

    private static IMapper Mapper => _mapper ?? throw new NullReferenceException("Please call the Configure method first.");

    private static void Configure(IMapper mapper)
    {
        _mapper = mapper;
    }

    public static IHost UseAutoMapper(this IHost app)
    {
        Configure(app.Services.GetRequiredService<IMapper>());
        return app;
    }

    /// <summary>
    /// 映射到对象
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj"> </param>
    /// <returns> </returns>
    public static T MapTo<T>(this object obj)
    {
        return Mapper.Map<T>(obj);
    }

    /// <summary>
    /// 映射到对象
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj"> </param>
    /// <returns> </returns>
    public static IEnumerable<T> MapTo<T>(this IEnumerable<object> obj)
    {
        return Mapper.Map<IEnumerable<T>>(obj);
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    /// <param name="obj">  </param>
    /// <param name="dest"> </param>
    public static void Map<T>(this object obj, T dest)
    {
        Mapper.Map(obj, dest);
    }

    public static IQueryable<TOut> Map<TIn, TOut>(this IQueryable<TIn> source)
    {
        return Mapper.ProjectTo<TOut>(source);
    }
}