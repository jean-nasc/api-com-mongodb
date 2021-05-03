# api-com-mongodb
API que recebe os dados de pessoas infectadas pelo Coronavirus e persiste no MongoDB


* Para testar a aplicação, você precisará de uma Connection String que pode ser obtida em: https://www.mongodb.com/cloud/atlas/register

* Caso não tenha instalado, será muito útil utilizar o Postman para o envio de requisições à API: https://www.postman.com/downloads

__*Modelo Json:*__
~~~
{
	"dataNascimento": "1990-03-01",
	"sexo": "M",
	"latitude": -23.5630994,
	"longitude": -46.6565712
}
~~~

__*Projeto Base:*__ https://github.com/gabrielfbarros/dotnet-mongo
