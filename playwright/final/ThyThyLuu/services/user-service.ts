import { APIResponse } from "@playwright/test";
import { API_ENDPOINT, TOKEN } from "../constant/url";
import { APIUtils } from "../core/api/api";
import { UpdateUserRequest } from "../data-object/api/user-data";

export class UserService {

    private static headers = {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${TOKEN}`
    };

    static async getCurrentProject(): Promise<APIResponse> {
        return await APIUtils.get(`${API_ENDPOINT}/me`, {
            headers: this.headers
        });
    }
    
    static async updateUserProfile(data: UpdateUserRequest): Promise<APIResponse> {
        return await APIUtils.put(
            `${API_ENDPOINT}/me`,
            {
                headers: this.headers,
                data
            }
        );
    }
}