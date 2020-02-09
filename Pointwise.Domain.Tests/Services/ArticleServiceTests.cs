using Moq;
using NUnit.Framework;
using Pointwise.Domain.Enums;
using Pointwise.Domain.Interfaces;
using Pointwise.Domain.Models;
using Pointwise.Domain.Repositories;
using Pointwise.Domain.Services;
using System.Collections.Generic;

namespace Pointwise.Domain.Tests.Services
{
    [TestFixture]
    public class ArticleServiceTests
    {
        private Mock<IArticleRepository> repository;
        private ArticleService service;

        [SetUp]
        public void Setup()
        {
            // Arrage
            repository = new Mock<IArticleRepository>();
            service = new ArticleService(repository.Object);
        }

        [Test]
        public void GetAllArticles_WhenCalled_ReturnsAllArticles()
        {
            // Act
            service.GetAllArticles();

            // Assert
            repository.Verify(x => x.GetAllArticles());
        }

        [Test]
        public void GetById_WhenCalled_ReturnsArticleById()
        {
            // Arrange
            int id = 5;

            // Act
            service.GetById(id);

            // Assert
            repository.Verify(x => x.GetById(id));
        }

        [Test]
        public void GetArticlesByAuthor_WhenCalled_ReturnsArticlesByAuthor()
        {
            //Arrange
            string author = "Jitendra";

            // Act
            service.GetArticlesByAuthor(author);

            // Assert
            repository.Verify(x => x.GetArticlesByAuthor(author));
        }

        [Test]
        public void GetArticleByTitle_WhenCalled_ReturnsArticlesByTitle()
        {
            // Arrange
            string title = "Padma Prizes";

            // Act
            service.GetArticleByTitle(title);

            // Assert
            repository.Verify(x => x.GetArticleByTitle(title));
        }

        [Test]
        public void GetArticleByDescription_WhenCalled_ReturnsArticlesByDesc()
        {
            // Arrange
            string descString = "Coronavirus";

            // Act
            service.GetArticleByDescription(descString);

            // Assert
            repository.Verify(x => x.GetArticleByDescription(descString));
        }

        [Test]
        public void GetArticleByContent_WhenCalled_ReturnsArticlesByContent()
        {
            // Arrange
            string contentString = "This is content of an article";

            // Act
            service.GetArticleByContent(contentString);

            // Assert
            repository.Verify(x => x.GetArticleByContent(contentString));
        }

        [Test]
        public void GetArticleBySource_WhenCalled_ReturnsArticlesBySource()
        {
            // Arrange
            var source = new Mock<ISource>();

            // Act
            service.GetArticleBySource(source.Object);

            // Assert
            repository.Verify(x => x.GetArticleBySource(source.Object));
        }

        [Test]
        public void GetArticleByCategory_WhenCalled_ReturnsArticlesByCategory()
        {
            // Arrange
            var category = new Mock<ICategory>();

            // Act
            service.GetArticleByCategory(category.Object);

            // Assert
            repository.Verify(x => x.GetArticleByCategory(category.Object));
        }

        [Test]
        public void GetArticleByAssetType_WhenCalled_ReturnsArtilesByAssetType()
        {
            // Arrange
            var assetType = ArticleAssociatedAssetType.Image;

            // Act
            service.GetArticleByAssetType(assetType);

            // Assert
            repository.Verify(x => x.GetArticleByAssetType(assetType));
        }

        [Test]
        public void Add_WhenCalled_AddsArticle()
        {
            // Arrange
            var article = new Mock<Article>();

            // Act
            service.Add(article.Object);

            // Assert
            repository.Verify(x => x.Add(article.Object));
        }

        [Test]
        public void AddRange_WhenCalled_AddsArticles()
        {
            // Arrange
            var articles = new Mock<IEnumerable<Article>>();

            // Act
            service.AddRange(articles.Object);

            // Assert
            repository.Verify(x => x.AddRange(articles.Object));
        }

        [Test]
        public void Remove_WhenCalled_RemovesArticle()
        {
            // Arrange
            int id = 5;

            // Act
            service.Remove(id);

            //
            repository.Verify(x => x.Remove(id));
        }

        [Test]
        public void RemoveRange_WhenCalled_RemovesArticlesByIds()
        {
            // Arrange
            var articles = new Mock<IEnumerable<Article>>();

            // Act
            service.RemoveRange(articles.Object);

            // Assert
            repository.Verify(x => x.RemoveRange(articles.Object));
        }

        [Test]
        public void Update_WhenCalled_UpdatesArticle()
        {
            // Arrnage
            var article = new Mock<Article>();
            article.Setup(x => x);

            // Act
            service.Update(article.Object);

            // Assert
            repository.Verify(x => x.Update(article.Object));

        }

    }
}
