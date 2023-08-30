import { useState } from "react";
import axios from "axios";
import { backendUrl } from "utils/utils";

const [name, setName] = useState("");
const [email, setEmail] = useState("");
const [responseText, setResponseText] = useState("");

const handleUpdateRequest = () => {
  // Dados que serão enviados no corpo da requisição PUT
  const putData = {
    name: name,
    email: email,
  };

  axios
    .put(backendUrl + "/1", putData) // Substitua '1' pelo ID correto
    .then((response) => {
      setResponseText("Atualização bem-sucedida! Resposta: " + response.data);
    })
    .catch((error) => {
      console.error("Erro ao fazer PUT:", error);
      setResponseText("Erro ao fazer a atualização.");
    });
};
