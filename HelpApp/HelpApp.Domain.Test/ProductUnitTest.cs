using HelpApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace HelpApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes positivos
        [Fact(DisplayName= "Create Product, with parameters Values")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action= () => new Product ( "Product Name", "Product Description", 99,1 ,  "/img/productimg.jpg" );
            action.Should().NotThrow<HelpApp.Domain.Validation.DomainExceptionValidation>();
        }
        #endregion
        #region Testes Negativos
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidId_ResultObjectException()
        {
            Action action = () => new Product (-1, "name","description", 9, 12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Update Invalid Id Value");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidName_ResultObjectException()
        {
            Action action = () => new Product (1, null, "description", 9, 12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Name Too Short")]
        public void CreateProduct_WithTooShort_ResultObjectException()
        {
            Action action = () => new Product(1, "Pa", "description", 9, 12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Description")]
        public void CreateProduct_WithInvalidDescription_ResultObjectException()
        {
            Action action = () => new Product(1, "name", null, 9, 12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Descrption Too Short")]
        public void CreateProduct_WithTooShortDescription_ResultObjectException()
        {
            Action action = () => new Product(1, "name", "Desc", 9, 12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPrice_ResultObjectException()
        {
            Action action = () => new Product(1, "name", "Desc", 9, 12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidStock_ResultObjectException()
        {
            Action action = () => new Product(1, "name", "Desc", 9, -12, "/img/productimg.jpg");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidImageName_ResultObjectException()
        {
            Action action = () => new Product(1, "name", "Desc", 9, 12, "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            action.Should().Throw<HelpApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        #endregion
    }
}
