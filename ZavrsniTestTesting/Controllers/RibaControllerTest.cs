using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZavrsniTest.Controllers;
using ZavrsniTest.Models;
using ZavrsniTest.Models.DTO;
using ZavrsniTest.Repository.Interface;

namespace ZavrsniTestTesting.Controllers
{
    public class RibaControllerTest
    {
        [Fact]
        public void GetRiba_ValidId_ReturnsObject()
        {
            // Arrange
            Riba riba = new Riba()
            {
                Id = 1,
                Sorta = "Saran",
                Mesto = "Smederevo",
                Cena = 1400,
                Kolicina = 10,
                RibarnicaId = 1,
                Ribarnica = new Ribarnica() { Id = 1, Naziv = "Lidl", GodinaOtvaranja = 1951 }
            };

            RibaDTO ribaDTO = new RibaDTO()
            {
                Id = 1,
                Sorta = "Saran",
                Mesto = "Smederevo",
                Cena = 1400,
                Kolicina = 10,
                RibarnicaId = 1,
                RibarnicaNaziv = "Lidl",
                RibarnicaGodinaOtvaranja = 1951
            };

            var mockRepository = new Mock<IRibaRepository>();
            mockRepository.Setup(x => x.GetById(1)).Returns(riba);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new RibaController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.GetRiba(1) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            RibaDTO dtoResult = (RibaDTO)actionResult.Value;
            Assert.Equal(riba.Id, dtoResult.Id);
            Assert.Equal(riba.Sorta, dtoResult.Sorta);
            Assert.Equal(riba.Mesto, dtoResult.Mesto);
            Assert.Equal(riba.Cena, dtoResult.Cena);
            Assert.Equal(riba.Kolicina, dtoResult.Kolicina);
            Assert.Equal(riba.RibarnicaId, dtoResult.RibarnicaId);
            Assert.Equal(riba.Ribarnica.GodinaOtvaranja, dtoResult.RibarnicaGodinaOtvaranja);
            Assert.Equal(riba.Ribarnica.Naziv, dtoResult.RibarnicaNaziv);
        }
        [Fact]
        public void PutRiba_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            Riba riba = new Riba()
            {
                Id = 1,
                Sorta = "Saran",
                Mesto = "Smederevo",
                Cena = 1400,
                Kolicina = 10,
                RibarnicaId = 1,
                Ribarnica = new Ribarnica() { Id = 1, Naziv = "Lidl", GodinaOtvaranja = 1951 }
            };

            var mockRepository = new Mock<IRibaRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new RibaController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.PutRiba(24, riba) as BadRequestResult;

            // Assert
            Assert.NotNull(actionResult);
        }
        [Fact]
        public void DeleteRiba_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IRibaRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new RibaController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.DeleteRiba(12) as NotFoundResult;

            // Assert
            Assert.NotNull(actionResult);
        }
        [Fact]
        public void Pretraga_ReturnsCollection()
        {
            // Arrange
            List<Riba> ribe = new List<Riba>() {
                new Riba()
                {
                    Id = 1,
                    Sorta = "Saran",
                    Mesto = "Smederevo",
                    Cena = 1400,
                    Kolicina = 10,
                    RibarnicaId = 1,
                    Ribarnica = new Ribarnica() { Id = 1, Naziv = "Lidl", GodinaOtvaranja = 1951 }
                },
                new Riba()
                {
                    Id = 2,
                    Sorta = "Saran",
                    Mesto = "Smederevo",
                    Cena = 1400,
                    Kolicina = 11,
                    RibarnicaId = 1,
                    Ribarnica = new Ribarnica() { Id = 2, Naziv = "Lidl", GodinaOtvaranja = 1951 }
                }
            };
            var mockRepository = new Mock<IRibaRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(ribe.AsQueryable());

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new RibaController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.Pretraga(10,11) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<RibaDTO> listResult = (List<RibaDTO>)actionResult.Value;

            for (int i = 0; i < listResult.Count; i++)
            {
                Assert.Equal(ribe[i].Id, listResult[i].Id);
                Assert.Equal(ribe[i].Sorta, listResult[i].Sorta);
                Assert.Equal(ribe[i].Mesto, listResult[i].Mesto);
                Assert.Equal(ribe[i].Cena, listResult[i].Cena);
                Assert.Equal(ribe[i].Kolicina, listResult[i].Kolicina);
                Assert.Equal(ribe[i].RibarnicaId, listResult[i].RibarnicaId);
                Assert.Equal(ribe[i].Ribarnica.GodinaOtvaranja, listResult[i].RibarnicaGodinaOtvaranja);
                Assert.Equal(ribe[i].Ribarnica.Naziv, listResult[i].RibarnicaNaziv);
            }
        }
    }
}
