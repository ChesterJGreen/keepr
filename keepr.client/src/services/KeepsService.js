import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    logger.log('in the service, before hitting server')
    const res = await api.get('api/keeps')
    logger.log(res.data)
    AppState.keeps = res.data
  }
}
export const keepsService = new KeepsService()
