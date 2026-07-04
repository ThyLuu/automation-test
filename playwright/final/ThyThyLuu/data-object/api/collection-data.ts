export interface CreateCollectionRequest {
    title: string;
    description?: string;
    private?: boolean;
}

export interface CollectionResponse {
    id: string;
    title: string;
    description: string;
    private: boolean;
}