<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\UtmCampaign;

class UtmCampaignSearch extends UtmCampaign
{
    public function rules()
    {
        return [
            [['id', 'user_id', 'stage_id', 'is_website', 'color', 'create_uid', 'write_uid', 'company_id'], 'integer'],
            [['name', 'create_date', 'write_date'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = UtmCampaign::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'user_id' => $this->user_id,
            'stage_id' => $this->stage_id,
            'is_website' => $this->is_website,
            'color' => $this->color,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'company_id' => $this->company_id,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
         ;

        return $dataProvider;
    }
}
