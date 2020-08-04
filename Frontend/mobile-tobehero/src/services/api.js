import axios from 'axios';

const api = axios.create({
  baseURL: `http://10.12.4.217:4300`
});

export default api;