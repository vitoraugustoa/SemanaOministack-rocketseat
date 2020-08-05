import axios from 'axios';

const api = axios.create({
  baseURL: `http://192.168.100.5:5000`,
  headers: {"Authorization": "1623335306"}
});

export default api;