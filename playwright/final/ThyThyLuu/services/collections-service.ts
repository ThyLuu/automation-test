import { APIResponse } from "@playwright/test";
import { API_ENDPOINT, TOKEN } from "../constant/url";
import { APIUtils } from "../core/api/api";
import { CreateCollectionRequest } from "../data-object/api/collection-data";

export class CollectionsService {

    private static headers = {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${TOKEN}`
    };

    static async getListOfCollections(): Promise<APIResponse> {
        return await APIUtils.get(`${API_ENDPOINT}/collections`, {
            headers: this.headers
        });
    }

    static async createCollection(data: CreateCollectionRequest): Promise<APIResponse> {
        return await APIUtils.post(
            `${API_ENDPOINT}/collections`,
            {
                headers: this.headers,
                data
            }
        );
    }

    static async deleteCollection(collectionId: string): Promise<APIResponse> {
        return await APIUtils.delete(
            `${API_ENDPOINT}/collections/${collectionId}`,
            {
                headers: this.headers
            }
        );
    }
}