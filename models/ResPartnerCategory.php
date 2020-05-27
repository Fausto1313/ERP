<?php

namespace app\models;

use Yii;

class ResPartnerCategory extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_partner_category';
    }

    public function rules()
    {
        return [
            [['parent_path', 'name'], 'string'],
            [['name'], 'required'],
            [['color', 'parent_id', 'active', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial509'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['parent_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartnerCategory::className(), 'targetAttribute' => ['parent_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'parent_path' => 'Parent Path',
            'name' => 'Name',
            'color' => 'Color',
            'parent_id' => 'Parent ID',
            'active' => 'Active',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial509' => 'Trial509',
        ];
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getParent()
    {
        return $this->hasOne(ResPartnerCategory::className(), ['id' => 'parent_id']);
    }

    public function getResPartnerCategories()
    {
        return $this->hasMany(ResPartnerCategory::className(), ['parent_id' => 'id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new ResPartnerCategoryQuery(get_called_class());
    }
}
