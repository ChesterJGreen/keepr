import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultsService {
  async getAll() {
    const res = await api.get('api/vaults')
    logger.log(res.data)
    AppState.vaults = res.data
  }

  async getAllByCreator() {
    const res = await api.get('account/vaults')
    logger.log(res.data)
    AppState.myVaults = res.data
  }
}
export const vaultsService = new VaultsService()
