import AsyncStorage from "@react-native-async-storage/async-storage";

import { SETTINGS_COLLECTION } from "../storageConfig";
import { Settings } from "./definitions";

export async function getSetting() {
  try {
    const storage = await AsyncStorage.getItem(`${SETTINGS_COLLECTION}`);

    const sets: Settings = storage
      ? JSON.parse(storage)
      : { tables: undefined };

    return sets;
  } catch (err) {
    throw err;
  }
}