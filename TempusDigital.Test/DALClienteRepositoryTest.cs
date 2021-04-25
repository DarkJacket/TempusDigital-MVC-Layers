using System;
using Xunit;
using Moq;
using DAL.Repositories;
using DAL;
using System.Linq;
using BOL.Entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TempusDigital.Test
{
    public class DALClienteRepositoryTest
    {
        [Fact]
        public void GetAll_ReturnListOfClients()
        {
            // AAA(Arrange, Act, Assert) 

            //Arrange
            var mockDbSet = new Mock<DbSet<Cliente>>();
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.Provider).Returns(ListOfClients().Provider);
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.Expression).Returns(ListOfClients().Expression);
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.ElementType).Returns(ListOfClients().ElementType);
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.GetEnumerator()).Returns(ListOfClients().GetEnumerator());

            var mockContext = new Mock<TempusDigitalContext>();
            mockContext.Setup(e => e.Set<Cliente>()).Returns(mockDbSet.Object);
                
            var CRepo = new ClienteRepository(mockContext.Object);

            var expect = ListOfClients().ToList();

            //act
            var actual = CRepo.GetAll().ToList();

            //asset
            Assert.True(actual != null);
            Assert.Equal(expect.Count(), actual.Count());
            Assert.Equal(expect[0].Nome, actual[0].Nome);

        }

        [Theory]
        [InlineData("48979611811")]
        [InlineData("5")]
        public void GetById_ReturnClient(string cpfValue)
        {
            // AAA(Arrange, Act, Assert) 

            //Arrange
            var mockDbSet = new Mock<DbSet<Cliente>>();
            mockDbSet.Setup(m => m.Find(cpfValue)).Returns(this.ListOfClients().FirstOrDefault(c => c.CPF == cpfValue));

             var mockContext = new Mock<TempusDigitalContext>();
            mockContext.Setup(e => e.Set<Cliente>()).Returns(mockDbSet.Object);

            var CRepo = new ClienteRepository(mockContext.Object);

            var expect = ListOfClients().FirstOrDefault(c => c.CPF == cpfValue);

            //act
            var actual = CRepo.GetById(cpfValue);

            //asset

            if (expect != null)
            {
                Assert.True(actual != null);
                Assert.Equal(expect.Nome, actual.Nome);
            }
            else
                Assert.True(actual == null);
            
        }

        [Fact]
        public void Where_ReturnListOfClient()
        {
            // AAA(Arrange, Act, Assert) 

            //Arrange
            var mockDbSet = new Mock<DbSet<Cliente>>();
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.Provider).Returns(ListOfClients().Provider);
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.Expression).Returns(ListOfClients().Expression);
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.ElementType).Returns(ListOfClients().ElementType);
            mockDbSet.As<IQueryable<Cliente>>().Setup(m => m.GetEnumerator()).Returns(ListOfClients().GetEnumerator());

            var mockContext = new Mock<TempusDigitalContext>();
            mockContext.Setup(e => e.Set<Cliente>()).Returns(mockDbSet.Object);

            var CRepo = new ClienteRepository(mockContext.Object);

            //act
            var actual = CRepo.Where(c => c.RendaFamiliar >= 5000);

            //asset
            Assert.Equal(actual.Count(), ListOfClients().Where(c => c.RendaFamiliar >= 5000).Count());
            mockDbSet.As<IQueryable<Cliente>>().Verify(c => c.Provider, Times.Exactly(1));




        }

        [Fact]
        public void Add_ReturnVoid()
        {
            // AAA(Arrange, Act, Assert) 

            //Arrange
            var newCliente = new Cliente("Douglas", "48979611811", new DateTime(1991), 2000);

            var mockDbSet = new Mock<DbSet<Cliente>>();

            var mockContext = new Mock<TempusDigitalContext>();
            mockContext.Setup(e => e.Set<Cliente>()).Returns(mockDbSet.Object);

            var CRepo = new ClienteRepository(mockContext.Object);

            //act
            CRepo.Add(newCliente);

            //asset
            Assert.True(newCliente.DataCadastro.Date == DateTime.Today);
            mockDbSet.Verify(c => c.Add(newCliente), Times.Exactly(1));
            mockContext.Verify(c => c.SaveChanges(), Times.Exactly(1));

        }

        [Fact]
        public void AddRange_ReturnVoid()
        {
            // AAA(Arrange, Act, Assert) 

            //Arrange
            var newCliente = ListOfClients();

            var mockDbSet = new Mock<DbSet<Cliente>>();

            var mockContext = new Mock<TempusDigitalContext>();
            mockContext.Setup(e => e.Set<Cliente>()).Returns(mockDbSet.Object);

            var CRepo = new ClienteRepository(mockContext.Object);

            //act
            CRepo.AddRange(newCliente);

            //asset
            mockDbSet.Verify(c => c.AddRange(newCliente), Times.Exactly(1));
            mockContext.Verify(c => c.SaveChanges(), Times.Exactly(1));

        }

        [Fact]
        public void Remove_ReturnVoid()
        {
            // AAA(Arrange, Act, Assert) 

            //Arrange
            var removeCliente = new Cliente("Douglas", "48979611811", new DateTime(1991), 2000);

            var mockDbSet = new Mock<DbSet<Cliente>>();
            mockDbSet.Setup(m => m.Remove(It.IsAny<Cliente>()));

            var mockContext = new Mock<TempusDigitalContext>();
            mockContext.Setup(e => e.Set<Cliente>()).Returns(mockDbSet.Object);

            var CRepo = new ClienteRepository(mockContext.Object);

            //act
            CRepo.Delete(removeCliente);

            //asset
            mockDbSet.Verify(c => c.Remove(removeCliente), Times.Exactly(1));
            mockContext.Verify(c => c.SaveChanges(), Times.Exactly(1));

        }


        private IQueryable<Cliente> ListOfClients()
        {
            return new List<Cliente>()
            {
                new Cliente("Douglas", "48979611811", new DateTime(1991), 2000),
                new Cliente("Fernanda", "111111111111", new DateTime(1992), 9000),
                new Cliente("Diogo", "22222222222", new DateTime(1996), 5000),
                new Cliente("Glaucia", "33333333333", new DateTime(1999), 1000)

            }.AsQueryable();
        }
    }
}
