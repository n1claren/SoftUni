import * as api from './api.js';

const host = 'http://localhost:3030';
api.settings.host = host;

export const register = api.register;
export const login = api.login;
export const logout = api.logout;

export async function getFurniture() {
    return await api.get(host + '/data/catalog');
}

export async function getItemByID(id) {
    return await api.get(host + '/data/catalog/' + id);
}

export async function getMyFurniture() {
    const userID = sessionStorage.getItem('userID');
    return await api.get(host + `/data/catalog?where=_ownerId%3D%22${userID}%22`);
}

export async function createFurniture(data) {
    return await api.post(host + '/data/catalog', data);
}

export async function editFurniture(data, id) {
    return await api.put(host + '/data/catalog/' + id, data);
}

export async function deleteFurniture(id) {
    return await api.del(host + '/data/catalog/' + id);
}