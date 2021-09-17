import { data } from 'jquery'
import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultKeepsService {
  async create(newVk) {
    const res = await api.post('/api/vaultkeeps', newVk)
    logger.log(res.data)
    AppState.vaultKeeps.push(res.data)
  }

  async delete(id) {
    const res = await api.delete(`api/vaultkeeps/${id}`)
    logger.log(res.data)
    AppState.vaultKeeps.filter(v => v.id === id)
  }
}
export const vaultkeepsService = new VaultKeepsService()
