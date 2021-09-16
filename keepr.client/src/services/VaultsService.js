import { data } from 'jquery'
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

  async getAllByProfile(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    logger.log(res.data)
    AppState.activeVaults = res.data
  }

  async getById(id) {
    const res = await api.get(`api/vaults/${id}`)
    logger.log(res.data)
    AppState.activeVault = res.data
  }

  async createVault(rawVault) {
    const res = await api.post('api/vaults', rawVault)
    AppState.myVaults.push(res.data)
    logger.log(res.data)
  }

  async deleteVault(id) {
    const res = await api.delete(`api/vaults/${id}`)
    logger.log(res.data)
    AppState.activeVault.filter(v => v.id !== id)
    AppState.vaults.filter(v => v.id !== id)
  }
}
export const vaultsService = new VaultsService()
