using CadCaminhoes.Controllers;
using CadCaminhoes.Data;
using CadCaminhoes.Models;
using CadCaminhoes.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CadCaminhoesTest
{
    [TestClass]
    public class UnitTestCaminhaos
    {
        [TestMethod]
        //Filtro de ano Fabricação e ano modelo são executados dentro do metodo Index na controller "camimnhaos"
        public void TesteModeloIndexAnoFabricacaoModeloPassado(CaminhaosController Caminhaos, CaminhaoContext context)
        {
            var anoAtual = DateTime.Now.Year;
            var anoSubsequente = anoAtual - 1;

            var ListaCaminhoes = context.Caminhoes.Include(c => c.Modelo)
            .Where(c => c.AnoFabricacao >= new DateTime(anoAtual, 1, 1))
            .Where(c => c.AnoFabricacao <= new DateTime(anoAtual, 12, 31))
            .Where(c => c.DataModelo >= new DateTime(anoAtual, 1, 1))
            .Where(c => c.DataModelo <= new DateTime(anoSubsequente, 12, 31));

            Assert.AreEqual(ListaCaminhoes, null);
        }

        [TestMethod]

        public void TesteModeloIndexAnoFabricacaoPosterior(CaminhaosController Caminhaos, CaminhaoContext context)
        {
            var anoAtual = DateTime.Now.Year;
            var anoSubsequente = anoAtual + 1;
            anoAtual += 1;

            var ListaCaminhoes = context.Caminhoes.Include(c => c.Modelo)
            .Where(c => c.AnoFabricacao >= new DateTime(anoAtual, 1, 1))
            .Where(c => c.AnoFabricacao <= new DateTime(anoAtual, 12, 31))
            .Where(c => c.DataModelo >= new DateTime(anoAtual, 1, 1))
            .Where(c => c.DataModelo <= new DateTime(anoSubsequente, 12, 31));

            Assert.AreEqual(ListaCaminhoes, null);
        }

        [TestMethod]
        public async void TesteModeloIndexOk(CaminhaosController Caminhaos, CaminhaoContext context)
        {
            List<Caminhao> listaAtual = new List<Caminhao>();
            List<Caminhao> listaEsperada = new List<Caminhao>();
            listaAtual = (List<Caminhao>)await Caminhaos.Index();
            Assert.AreEqual(listaAtual, listaEsperada);
        }

        [TestMethod]
        public async void TesteModeloIndexNOk(CaminhaosController Caminhaos, CaminhaoContext context)
        {
            List<Caminhao> listaAtual = new List<Caminhao>();
            List<Caminhao> listaEsperada = new List<Caminhao>();
            listaAtual = (List<Caminhao>)await Caminhaos.Index();
            Assert.AreNotEqual(listaAtual, listaEsperada);
        }

        [TestMethod]
        public async void TesteModeloDetailsOk(int? ID, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Details(ID);
            Assert.AreEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloDetailsNOk(int? ID, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Details(ID);
            Assert.AreNotEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloCreateOk(Caminhao caminhao, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Create(caminhao);
            Assert.AreEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloCreateNOk(Caminhao caminhao, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Create(caminhao);
            Assert.AreNotEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloEditOk(int? ID, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Edit(ID);
            Assert.AreEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloEditNOk(int? ID, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Edit(ID);
            Assert.AreNotEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloEditOk(int ID, Caminhao caminhao, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Edit(ID, caminhao);
            Assert.AreEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloEditNOk(int ID, Caminhao caminhao, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Edit(ID, caminhao);
            Assert.AreNotEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloDeleteOk(int? ID,CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Delete(ID);
            Assert.AreEqual(CaminhaoAtual, CaminhaoEsperado);
        }

        [TestMethod]
        public async void TesteModeloDeleteNOk(int? ID, CaminhaosController Caminhaos)
        {
            Caminhao CaminhaoAtual = new Caminhao();
            Caminhao CaminhaoEsperado = new Caminhao();
            CaminhaoAtual = (Caminhao)await Caminhaos.Delete(ID);
            Assert.AreNotEqual(CaminhaoAtual, CaminhaoEsperado); 
        }
    }
}
