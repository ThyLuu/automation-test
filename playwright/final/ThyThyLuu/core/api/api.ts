import { APIResponse } from "@playwright/test";
import { BrowserManagement } from "../browser/browser-management";

interface ApiOptions {
    params?: Record<string, string | number | boolean>;
    headers?: Record<string, string>;
    data?: Record<string, any> | string;
}

export class APIUtils {

    private static buildUrl(url: string, params?: Record<string, string | number | boolean>): string {
        const query = params
            ? new URLSearchParams(
                Object.entries(params).reduce(
                    (acc, [key, value]) => ({
                        ...acc,
                        [key]: String(value)
                    }),
                    {}
                )
            ).toString()
            : "";

        return query ? `${url}?${query}` : url;
    }

    static async get(url: string, option?: ApiOptions): Promise<APIResponse> {
        return await BrowserManagement.getCurrentRequest().get(
            this.buildUrl(url, option?.params),
            {
                headers: option?.headers
            }
        );
    }

    static async post(url: string, option?: ApiOptions): Promise<APIResponse> {
        return await BrowserManagement.getCurrentRequest().post(
            this.buildUrl(url, option?.params),
            {
                headers: option?.headers,
                data: option?.data
            }
        );
    }

    static async put(url: string, option?: ApiOptions): Promise<APIResponse> {
        return await BrowserManagement.getCurrentRequest().put(
            this.buildUrl(url, option?.params),
            {
                headers: option?.headers,
                data: option?.data
            }
        );
    }

    static async delete(url: string, option?: ApiOptions): Promise<APIResponse> {
        return await BrowserManagement.getCurrentRequest().delete(
            this.buildUrl(url, option?.params),
            {
                headers: option?.headers
            }
        );
    }
}