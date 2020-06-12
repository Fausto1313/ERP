<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResCountry;

class ResCountrySearch extends ResCountry
{
    public function rules()
    {
        return [
            [['id', 'address_view_id', 'currency_id', 'phone_code', 'create_uid', 'write_uid'], 'integer'],
            [['name', 'code', 'address_format', 'name_position', 'vat_label', 'create_date', 'write_date', 'trial434'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ResCountry::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'address_view_id' => $this->address_view_id,
            'currency_id' => $this->currency_id,
            'phone_code' => $this->phone_code,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'code', $this->code])
            ->andFilterWhere(['like', 'address_format', $this->address_format])
            ->andFilterWhere(['like', 'name_position', $this->name_position])
            ->andFilterWhere(['like', 'vat_label', $this->vat_label])
            ->andFilterWhere(['like', 'trial434', $this->trial434]);

        return $dataProvider;
    }
}
