<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\CrmTeam;
class CrmTeamSearch extends CrmTeam
{
    public function rules()
    {
       return [
            [['message_main_attachment_id', 'sequence', 'company_id', 'user_id', 'color', 'create_uid', 'write_uid', 'use_leads', 'use_opportunities', 'alias_id', 'use_quotations', 'invoiced_target'], 'integer'],
            [['alias_id'], 'required'],
            [['name', 'company_name', 'active'], 'string'],
            [['create_date', 'write_date'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = CrmTeam::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,        
            'message_main_attachment_id' => $this->message_main_attachment_id,
            'name' => $this->name,
            'sequence' => $this->sequence,
            'active' => $this->active,
            'company_id' => $this->company_id,
            'company_name' => $this->company_name,
            'user_id' => $this->user_id,
            'color' => $this->color,
            'create_uid' => $this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_Date,
            'use_leads' => $this->use_leads,
            'use_opportunities' => $this->use_opportunities,
            'alias_id' => $this->alias_id,
            'use_quotations' => $this->use_quotations,
            'invoiced_target' => $this->invoiced_target,
            'trial304' => $this->trial304,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'sequence', $this->sequence])
            ->andFilterWhere(['like', 'active', $this->active])
            ->andFilterWhere(['like', 'company_id', $this->company_id])
            ->andFilterWhere(['like', 'company_name', $this->company_name])
            ->andFilterWhere(['like', 'user_id', $this->user_id])
            ->andFilterWhere(['like', 'color', $this->color])
            ->andFilterWhere(['like', 'create_uid', $this->create_uid])
            ->andFilterWhere(['like', 'create_date', $this->create_date])
            ->andFilterWhere(['like', 'write_uid', $this->write_uid])
            ->andFilterWhere(['like', 'write_date', $this->write_date])
            ->andFilterWhere(['like', 'use_leads', $this->use_leads])
            ->andFilterWhere(['like', 'use_opportunities', $this->use_opportunities]);

        return $dataProvider;
    }
}
