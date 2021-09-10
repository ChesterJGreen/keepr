export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'http://localhost:3000' : 'http://localhost:8080' ? 'https://localhost:5000' : 'https://localhost:5001'
export const domain = 'chester-codeworks.us.auth0.com'
export const audience = 'https://Auth-todo.com'
export const clientId = 'gkeK1s9fque5NqCnELtwW5zHgN4IApCI'
