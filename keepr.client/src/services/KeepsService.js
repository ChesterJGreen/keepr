import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    logger.log(res.data)
    AppState.keeps = res.data
  }

  async getAllByProfile() {
    const res = await api.get()
    logger.log(res.data)
    AppState.myKeeps = res.data
  }

  async getAllByCreator(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log(res.data)
    AppState.myKeeps = res.data
  }

  async createKeep(rawKeep) {
    console.log('in the service')
    console.log(rawKeep)
    const res = await api.post('api/keeps', rawKeep)
    console.log('in the service after going to server')
    console.log(res.data)
    logger.log(res.data)
    AppState.myKeeps.push(res.data)
  }
}
export const keepsService = new KeepsService()
