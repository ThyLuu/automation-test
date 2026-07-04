import fs from "fs";

export class JsonHelper {
    static readJson<T>(absolutePath: string): T {
        if (!fs.existsSync(absolutePath)) {
            throw new Error(`[JsonHelper] Not found any file: ${absolutePath}`);
        }

        const content = fs.readFileSync(absolutePath, "utf-8");
        return JSON.parse(content) as T;
    }
}