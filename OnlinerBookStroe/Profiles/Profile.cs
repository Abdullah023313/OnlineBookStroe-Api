using AutoMapper;
using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;

namespace OnlinerBookStroe.Profiles
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<BookDto, Book>();

            CreateMap<Book, BookForResponseDto>()
                .ForMember(dest => dest.AuthorName, source => source.MapFrom(
                   s => s.Author.AuthorName))
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(
                   s => s.Category.CategoryName));


            CreateMap<Category, CategoryWithoutBook>();

            CreateMap<Category, CategoryWithBook>()
                .ForMember(dest => dest.books, source => source.MapFrom(
                   s => s.books));
        }
    }
}