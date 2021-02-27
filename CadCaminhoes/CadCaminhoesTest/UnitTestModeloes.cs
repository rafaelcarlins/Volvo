using CadCaminhoes.Controllers;
using CadCaminhoes.Data;
using CadCaminhoes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CadCaminhoesTest
{
    [TestClass]
    public class UnitTestModeloes
    {
        [TestMethod]
        public async void TesteModeloIndexOk(ModeloesController modeloes, CaminhaoContext context)
        {
            List<Modelo> listaAtual = new List<Modelo>();
            List<Modelo> listaEsperada = new List<Modelo>();
            listaAtual = (List<Modelo>)await modeloes.Index();
            Assert.AreEqual(listaAtual, listaEsperada);
        }

        [TestMethod]
        public async void TesteModeloIndexNOk(ModeloesController modeloes, CaminhaoContext context)
        {
            List<Modelo> listaAtual = new List<Modelo>();
            List<Modelo> listaEsperada = new List<Modelo>();
            listaAtual = (List<Modelo>)await modeloes.Index();
            Assert.AreNotEqual(listaAtual, listaEsperada);
        }

        [TestMethod]
        public async void TesteModeloDetailsOk(int? ID, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Details(ID);
            Assert.AreEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloDetailsNOk(int? ID, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Details(ID);
            Assert.AreNotEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloCreateOk(Modelo modelo, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Create(modelo);
            Assert.AreEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloCreateNOk(Modelo modelo, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Create(modelo);
            Assert.AreNotEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloEditOk(int? ID, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Edit(ID);
            Assert.AreEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloEditNOk(int? ID, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Edit(ID);
            Assert.AreNotEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloEditOk(int ID, Modelo modelo, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Edit(ID, modelo);
            Assert.AreEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloEditNOk(int ID, Modelo modelo, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Edit(ID, modelo);
            Assert.AreNotEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloDeleteOk(int? ID,ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Delete(ID);
            Assert.AreEqual(ModeloAtual, ModeloEsperada);
        }

        [TestMethod]
        public async void TesteModeloDeleteNOk(int? ID, ModeloesController modeloes)
        {
            Modelo ModeloAtual = new Modelo();
            Modelo ModeloEsperada = new Modelo();
            ModeloAtual = (Modelo)await modeloes.Delete(ID);
            Assert.AreNotEqual(ModeloAtual, ModeloEsperada);
        }
    }
}
