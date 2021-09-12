import { AppState } from '../AppState'

const { api } = require('./AxiosService')

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    console.log(res.data)
    AppState.keeps = res.data
  }
}
export const keepsService = new KeepsService()
