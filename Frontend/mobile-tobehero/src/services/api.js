import axios from 'axios';

// Adicionar o IP da maquina para realizar a requisição
// em desenvolvimento.
// Caso esteja utilizando .NET/.NET Core para API
// Alterar o APP URL para o IP da maquina e a porta 5000 ou 5001  
const api = axios.create({
  baseURL: `http://localhost:5000`,
  headers: {"Authorization": "1623335306"}
});

export default api;