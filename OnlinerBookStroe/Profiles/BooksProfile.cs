using AutoMapper;
using OnlinerBookStroe.Dtos;
using OnlinerBookStroe.Model;

namespace OnlinerBookStroe.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<BookDto, Book>();

            CreateMap<Book, BookForDisplayDto>()
                .ForMember(dest => dest.AuthorName, source => source.MapFrom(
                   s => s.Author.AuthorName))
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(
                   s => s.Category.CategoryName));
        }
    }
}
    