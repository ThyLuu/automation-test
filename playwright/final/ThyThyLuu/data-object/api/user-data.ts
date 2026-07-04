export interface UpdateUserRequest {
    username?: string;
    first_name?: string;
    last_name?: string;
    email?: string;
    url?: string;
    location?: string;
    bio?: string;
    instagram_username?: string;
}

export interface UserLinks {
    self: string;
    html: string;
    photos: string;
}

export interface UpdateUserResponse {
    id: string;
    updated_at: string;

    username: string;
    first_name: string;
    last_name: string;

    twitter_username: string | null;
    portfolio_url: string | null;

    bio: string | null;
    location: string | null;
    email: string;

    total_collections: number;
    downloads: number;
    uploads_remaining: number;

    instagram_username: string | null;

    links: UserLinks;
}