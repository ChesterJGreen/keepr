import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class VaultKeepsService {
  async create(newVk) {
    const res = await api.post('/api/vaultkeeps', newVk)
    logger.log(res.data)
    AppState.vaultKeeps.push(res.data)
  }
}
export const vaultkeepsService = new VaultKeepsService()
