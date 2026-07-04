import { expect } from "@playwright/test";
import { UserService } from "../../services/user-service";

export class UserApiWorkflow {
    static async restoreProfile(profileData: any): Promise<void> {
        const response =await UserService.updateUserProfile(profileData);
        const updatedUser = await response.json();

        expect(response.status()).toBe(200);
        expect(updatedUser.username).toBe(profileData.username);
    }
}