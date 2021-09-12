import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    console.log(res.data)
    AppState.keeps = res.data
  }
}
export const keepsService = new KeepsService()
