import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    logger.log(res.data)
    AppState.keeps = res.data
  }

  async getAllByProfile(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log(res.data)
    AppState.activeKeeps = res.data
  }

  async getAllByCreator(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log(res.data)
    AppState.myKeeps = res.data
  }

  async getById(id) {
    const res = await api.get(`api/keeps/${id}`)
    logger.log(res.data)
    AppState.activeKeep = res.data
    const keep = AppState.keeps.find(k => k.id === id)
    keep.views = res.data.views
    keep.keeps = res.data.keeps
  }

  async getAllByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    logger.log(res.data)
    AppState.vaultKeeps = res.data
  }

  async createKeep(rawKeep) {
    const res = await api.post('api/keeps', rawKeep)
    logger.log(res.data)
    AppState.myKeeps.push(res.data)
  }

  async deleteKeep(id) {
    const res = await api.delete(`api/keeps/${id}`)
    logger.log(res.data)
    AppState.keeps = AppState.keeps.filter(k => k.id !== id)
    AppState.activeKeeps = AppState.activeKeeps.filter(k => k.id !== id)
    AppState.myKeeps = AppState.myKeeps.filter(k => k.id !== id)
  }
}
export const keepsService = new KeepsService()
