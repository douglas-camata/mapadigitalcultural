function init() {
    var objEstado = {
        "ac": [
            {
                "nome": "Acre",
                "capital": "Rio Branco",
                "regiao": "Norte"
            }],
        "al": [{
            "nome": "Alagoas",
            "capital": "Maceió",
            "regiao": "Nordeste"
        }],
        "ap": [{
            "nome": "Amapá",
            "capital": "Macapá",
            "regiao": "Norte"
        }],
        "am": [
            {
                "nome": "Amazonas",
                "capital": "Manaus",
                "regiao": "Norte"
            }],
        "ba": [{
            "nome": "Bahia",
            "capital": "Salvador",
            "regiao": "Nordeste"
        }],
        "ce": [{
            "nome": "Ceará",
            "capital": "Fortaleza",
            "regiao": "Nordeste"
        }],
        "df": [{
            "nome": "Distrito Federal",
            "capital": "Brasília",
            "regiao": "Centro-Oeste"
        }],
        "es": [{
            "nome": "Espírito Santo",
            "capital": "Vitória",
            "regiao": "Sudeste"
        }],
        "go": [{
            "nome": "Goiás",
            "capital": "Goiânia",
            "regiao": "Centro-Oeste"
        }],
        "ma": [{
            "nome": "Maranhão",
            "capital": "São Luís",
            "regiao": "Nordeste"
        }],
        "mt": [{
            "nome": "Mato Grosso",
            "capital": "Cuiabá",
            "regiao": "Centro-Oeste"
        }],
        "ms": [{
            "nome": "Mato Grosso do Sul",
            "capital": "Campo Grande",
            "regiao": "Centro-Oeste"
        }],
        "mg": [{
            "nome": "Minas Gerais",
            "capital": "Belo Horizonte",
            "regiao": "Sudeste"
        }],
        "pr": [{
            "nome": "Paraná",
            "capital": "Curitiba",
            "regiao": "Sul"
        }],
        "pb": [{
            "nome": "Paraíba",
            "capital": "João Pessoa",
            "regiao": "Nordeste"
        }],
        "pa": [{
            "nome": "Pará",
            "capital": "Belém",
            "regiao": "Norte"
        }],
        "pe": [{
            "nome": "Pernambuco",
            "capital": "Recife",
            "regiao": "Nordeste"
        }],
        "pi": [{
            "nome": "Piauí",
            "capital": "Terezina",
            "regiao": "Nordeste"
        }],
        "rj": [{
            "nome": "Rio de Janeiro",
            "capital": "Rio de Janeiro",
            "regiao": "Sudeste"
        }],
        "rn": [{
            "nome": "Rio Grande do Norte",
            "capital": "Natal",
            "regiao": "Nordeste"
        }],
        "rs": [{
            "nome": "Rio Grande do Sul",
            "capital": "Porto Alegre",
            "regiao": "Sul"
        }],
        "ro": [{
            "nome": "Rondônia",
            "capital": "Porto Velho",
            "regiao": "Norte"
        }],
        "rr": [{
            "nome": "Roraima",
            "capital": "Boa Vista",
            "regiao": "Norte"
        }],
        "sc": [{
            "nome": "Santa Catarina",
            "capital": "Florianópolis",
            "regiao": "Sul"
        }],
        "se": [{
            "nome": "Sergipe",
            "capital": "Aracaju",
            "regiao": "Nordeste"
        }],
        "sp": [{
            "nome": "São Paulo",
            "capital": "São Paulo",
            "regiao": "Sudeste"
        }],
        "to": [{
            "nome": "Tocantins",
            "capital": "Palmas",
            "regiao": "Norte"
        }]
    }

    var i = j = k = l = m = 0;
    var msg = document.getElementById('msg');
    var D = document.getElementById('E');
    SVGDoc = D.getSVGDocument();
    SVGRoot = SVGDoc.documentElement;
    svgns = 'http://www.w3.org/2000/svg';
    var estados = SVGRoot.getElementsByTagName('path');
    var qdeEstados = estados.length;
    var todasRegioes = SVGRoot.querySelectorAll('.regiao');
    var regiaoNorte = SVGRoot.querySelector('#norte');
    var regiaoNordeste = SVGRoot.querySelector('#nordeste');
    var regiaoSudeste = SVGRoot.querySelector('#sudeste');
    var regiaoCentroOeste = SVGRoot.querySelector('#centro-oeste');
    var regiaoSul = SVGRoot.querySelector('#sul');
    for (; i < qdeEstados; i++) {
        estados[i].onmouseover = function (evt) {
            var x = evt.pageX;
            var y = evt.pageY + 250;
            this.style.fill = this.getAttribute('fill');
            var siglaEstado = this.parentNode.id;

            $('#regiao_estado').html('Região: ' + objEstado[siglaEstado][0].regiao).css({
                top: y - 25,
                left: x,
                padding: '0 0.6em',
                border: '2px solid white',
                boxShadow: '4px 4px 6px #444'
            });
            $('#nome_estado').html('<img src="/bandeiras/' + siglaEstado + '.png" alt="" width="20" height="14" />' + objEstado[siglaEstado][0].nome).css({
                top: y,
                left: x,
                padding: '0 0.6em',
                border: '2px solid white',
                boxShadow: '4px 4px 6px #444'
            });

            $('#capital_estado').html('Capital: ' + objEstado[siglaEstado][0].capital).css({
                top: y + 25,
                left: x,
                padding: '0 0.6em',
                border: '2px solid white',
                boxShadow: '4px 4px 6px #444'
            });
        }
        estados[i].onmouseout = function () {
            var fillColor = this.getAttribute('fill');
            this.style.fill = fillColor;
            $('#nome_estado').html('').css({
                border: 'none',
            });
            $('#capital_estado').html('').css({
                border: 'none',
            });
            $('#regiao_estado').html('').css({
                border: 'none',
            });
        }
    }

    for (; m < qdeEstados; m++) { // Carregar descrição do estado  
        estados[m].onclick = function () {
            var estadoClicado = this.parentNode.id;

            //alert(objEstado[estadoClicado][0].regiao);
            window.location.href = "/Mapa/Interagir/" + objEstado[estadoClicado][0].regiao;
        }
    }

}
window.addEventListener("load", init, false);