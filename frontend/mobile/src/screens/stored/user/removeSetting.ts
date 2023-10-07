import AsyncStorage from "@react-native-async-storage/async-storage";

import { SETTINGS_COLLECTION } from "../storageConfig";
import { Settings } from "./definitions";

export async function removeUser(sets: Settings) {
  try {
    await AsyncStorage.removeItem(`${SETTINGS_COLLECTION}-${sets}`);
  } catch (err) {
    throw err;
  }
}
