import { expect } from "@playwright/test";
import { CollectionsService } from "../../services/collections-service";

export class CollectionApiWorkflow {
    static async createCollection(collectionName: string): Promise<any> {

        const response =
            await CollectionsService.createCollection({
                title: collectionName,
                description: "Created by API"
            });

        expect(response.status()).toBe(201);

        return await response.json();
    }

    static async deleteCollection(collectionId: string): Promise<void> {
        await CollectionsService.deleteCollection(collectionId);
    }
}